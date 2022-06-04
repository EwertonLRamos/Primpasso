using Microsoft.Extensions.DependencyInjection;
using Primpasso.BLL.Service;
using Primpasso.BLLInfra.Service;
using Primpasso.Context;
using Primpasso.DAL.Repositories;
using Primpasso.DAL.UnitsOfWork;
using Primpasso.DALInfra.Repositories;
using Primpasso.DALInfra.UnitsOfWork;

namespace Primpasso.IoC
{
    public static class DependencyInjectionHandler
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<PrimpassoDbContext>();

            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICandidateService, CandidateService>();
            service.AddScoped<IJobOpportunityService, JobOpportunityService>();

            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<ICandidateRepository, CandidateRepository>();
            service.AddScoped<IJobOpportunityRepository, JobOpportunityRepository>();

            service.AddScoped<ICompanyUow, CompanyUow>();
            service.AddScoped<ICandidateUow, CandidateUow>();
            service.AddScoped<IJobOpportunityUow, JobOpportunityUow>();

            return service;
        }
    }
}
