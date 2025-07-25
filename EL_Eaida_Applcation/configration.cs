﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation;
using EL_Eaida_Applcation.InterFaceServices;
using EL_Eaida_Applcation.InterFaceServices.IAppointmentServices;
using EL_Eaida_Applcation.InterFaceServices.IAutherServices;
using EL_Eaida_Applcation.InterFaceServices.IMedicalvisitServices;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;
using EL_Eaida_Applcation.InterFaceServices.IPresciptionitemServices;
using EL_Eaida_Applcation.InterFaceServices.IPrescriptionServices;
using EL_Eaida_Applcation.InterFaceServices.IRoleServices;
using EL_Eaida_Applcation.Services;
using EL_Eaida_Applcation.Services.PatientServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EL_Eaida_Applcation
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAppointmentService,AppointmentServices>();
            services.AddScoped<IPrescriptionServices, PrescriptionServices>();
            services.AddScoped<IMedicineServices, MedicineServices>();
            services.AddScoped<IPresciptionitemServices, PrescritionitemServices>();
            services.AddScoped<IMedicalVisitServices, MedicalVisitServices>();
            services.AddScoped<IPatientService, PatientServices>();
            services.AddScoped<IinvoiceServices, invoiceServices>();
            services.AddScoped<IinvoiceitemServices, InvoiceitemServices>();
            // Register AutoMapper (search all mappings in this assembly)
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
