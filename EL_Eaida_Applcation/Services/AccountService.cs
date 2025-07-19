
using System.Data;
using System.Security.Claims;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.TokenDTO;
using EL_Eaida_Applcation.DTO.UserDTo;
using EL_Eaida_Applcation.InterFaceServices.IAutherServices;
using Microsoft.AspNetCore.Identity;

namespace EL_Eaida_Applcation.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public AccountService(
            UserManager<User> userManager,
            ITokenRepository tokenRepository,
            IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new Exception("Invalid login attempt");

            }
            // Generate JWT token and refresh token
            // Assuming you have a method to generate tokens in your token repository
            var token = await _tokenRepository.GenerateToken(user);
            var refreshToken = await _tokenRepository.GenerateToken(user); // Assuming you have a method to generate refresh tokens
            await _tokenRepository.SaveRefreshTokenAsync(user.Id, refreshToken); // Save the refresh token in the database
            return new AuthResponseDto
            {
                Token = token,
                Refresh = token,
                User = _mapper.Map<UserDTO>(user)
            };

        }

        public Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var principal = _tokenRepository.GetPrincipalFromExpiredToken(dto.Token);
            if (principal == null)
            {
                throw new Exception("Invalid token");
            }
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new Exception("User ID not found in token");
            }
            var user = _userManager.FindByIdAsync(userId).Result;
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!_tokenRepository.ValidateRefreshTokenAsync(userId, dto.RefreshToken).Result)
            {
                throw new Exception("Invalid refresh token");
            }
            var newToken = _tokenRepository.GenerateToken(user).Result;
            var newRefreshToken = _tokenRepository.GenerateRefreshToken().Result;
            _tokenRepository.SaveRefreshTokenAsync(userId, newRefreshToken).Wait();
            return Task.FromResult(new AuthResponseDto
            {
                Token = newToken,
                Refresh = newRefreshToken,
                User = _mapper.Map<UserDTO>(user)
            });

        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Username; // أو dto.Email حسب ما تفضله
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // إضافة الأدوار للمستخدم
            foreach (var role in dto.Role)
            {
                if (await _roleManager.RoleExistsAsync(role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            var token = await _tokenRepository.GenerateToken(user);
            var refreshToken = await _tokenRepository.GenerateRefreshToken();
            await _tokenRepository.SaveRefreshTokenAsync(user.Id, refreshToken);

            return new AuthResponseDto
            {
                Token = token,
                Refresh = refreshToken,
                User = _mapper.Map<UserDTO>(user)
            };
        }
    }
    }
