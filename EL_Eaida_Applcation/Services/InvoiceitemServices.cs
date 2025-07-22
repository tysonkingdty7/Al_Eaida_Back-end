using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class InvoiceitemServices : IinvoiceitemServices
    { 
         protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public InvoiceitemServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<InvoiceItemDto> Createinvoiceitem(CreateInvoiceItemDto createInvoiceItemDto)
        {
            var invoiceItem = _mapper.Map<InvoiceItem>(createInvoiceItemDto);
              await  _unitOfWork.Repository<InvoiceItem>().AddAsync(invoiceItem);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<InvoiceItemDto>(invoiceItem) ;
        }

        public async Task<bool> DeleteInvoiceitem(Guid id)
        {
            var invoiceItem = _unitOfWork.Repository<InvoiceItem>().GetByIdAsync(id);
            if (invoiceItem == null)
            {
                throw new KeyNotFoundException("Invoice item not found");
            }
            var result = await _unitOfWork.Repository<InvoiceItem>().Delete(invoiceItem.Result);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<InvoiceItemDto>> GetAllInvoiceitems( int Pagesize , int pagenumber )
        {
           
            var invoiceItems = await  _unitOfWork.Repository<InvoiceItem>().GetAllAsync(pagenumber,Pagesize);
         
            var invoiceItemDtos = _mapper.Map<IEnumerable<InvoiceItemDto>>(invoiceItems);
            return invoiceItemDtos;

        }

        public async Task<InvoiceItemDto> GetInvoiceitemById(Guid id)
        {
           var invoiceItem = await  _unitOfWork.Repository<InvoiceItem>().GetByIdAsync(id);
            if (invoiceItem == null)
            {
                throw new KeyNotFoundException("Invoice item not found");
            }
            var invoiceItemDto = _mapper.Map<InvoiceItemDto>(invoiceItem);
            await _unitOfWork.CompleteAsync();
            return invoiceItemDto;
        }

        public async Task<IEnumerable<InvoiceItemDto>> GetInvoiceItemsByInvoiceId(Guid invoiceId)
        { 
             var invoiceItems = await _unitOfWork.Repository<InvoiceItem>().GetAllAsync(1, int.MaxValue);
            var filteredItems = invoiceItems.Where(ii => ii.InvoiceId == invoiceId).ToList();
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<IEnumerable<InvoiceItemDto>>(filteredItems);


        }

        public async Task<InvoiceItemDto> UpdateInvoiceitem(Guid id, UpdateInvoiceItemDto updateDto)
        {
            var invoiceItem = await _unitOfWork.Repository<InvoiceItem>().GetByIdAsync(id);
            if (invoiceItem == null)
            {
                throw new KeyNotFoundException("Invoice item not found");
            }

            
            if (!string.IsNullOrWhiteSpace(updateDto.Description))
            {
                invoiceItem.Description = updateDto.Description;
            }

            if (updateDto.Amount.HasValue)
            {
                invoiceItem.Amount = updateDto.Amount.Value;
            }

            await _unitOfWork.Repository<InvoiceItem>().Update(invoiceItem);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<InvoiceItemDto>(invoiceItem);
        }


    }
}
