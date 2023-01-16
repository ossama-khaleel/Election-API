using Election.CORE.Common;
using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using Election.INFR.Common;
using Election.INFR.Repository;
using Election.INFR.Service;
using EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Election.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender,EmailSender>();
            services.AddScoped<IDbContext, DbContext>();
            //Repositorys
            services.AddScoped<ISharedRepository<Ebloodtype>, BloodTypeRepository>();
            services.AddScoped<ISharedRepository<Ecandidateform>, CandidateFormRepository>();
            services.AddScoped<ISharedRepository<Ecandidate>, CandidateRepository>();
            services.AddScoped<ISharedRepository<Ecategory>, CategoryRepository>();
            services.AddScoped<ISharedRepository<Eelectionduration>, ElectionDurationRepository>();
            services.AddScoped<ISharedRepository<Egender>, GenderRepository>();
            services.AddScoped<ISharedRepository<Egovernorate>, GovernorateRepository>();
            services.AddScoped<ISharedRepository<Emunicipalname>, MunicipalNameRepository>();
            services.AddScoped<ISharedRepository<Eplaceandregnum>, PlaceAndRegNumRepository>();
            services.AddScoped<ISharedRepository<Eplaceofrelease>, PlaceOfReleaseRepository>();
            services.AddScoped<ISharedRepository<Eplaceswithinthemunicipal>, PlacesWithInTheMunicipalRepository>();
            services.AddScoped<ISharedRepository<Eplaceofresidence>, PlaceOfResidenceRepository>();
            services.AddScoped<ISharedRepository<Eplaceofresidencevillage>, PlaceofResidenceVillageRepository>();
            services.AddScoped<ISharedRepository<Erole>, RoleRepository>();
            services.AddScoped<ISharedRepository<Euserinformation>, UserInformationRepository>();
            services.AddScoped<ISharedRepository<Euservoted>, UserVotedRepository>();
            services.AddScoped<ISharedRepository<Euservote>, UserVoteRepository>();
            services.AddScoped<ISharedRepository<Euser>, UserRepository>();
            services.AddScoped<ISharedRepository<Emunicipalstatus>, MunicipalStatusRepository>();
            services.AddScoped<IMunicipalStatusRepository, MunicipalStatusRepository>();
            services.AddScoped<IMunicipalNameRepository, MunicipalNameRepository>();
            services.AddScoped<IJWTRepository, JWTRepository>();
            services.AddScoped<IRegisterRepository, UserRepository>();
            services.AddScoped<ISharedRepository<Etestimonial>, TestimonialRepository>();
            services.AddScoped<ISharedRepository<Eaboutu>, AboutuRepository>();
            services.AddScoped<ISharedRepository<Ehome>, HomeRepository>();
            services.AddScoped<ISharedRepository<Econtactu>, ContactuRepository>();
            services.AddScoped<ISharedRepository<Ereview>, ReviewRepository>();
            services.AddScoped<IEmailVerifyingRepository, EmailVerifyingRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IUserVotedRepository, UserVotedRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //Services
            services.AddScoped<ISharedService<Ebloodtype>, BloodTypeService>();
            services.AddScoped<ISharedService<Ecandidateform>, CandidateFormService>();
            services.AddScoped<ISharedService<Ecandidate>, CandidateService>();
            services.AddScoped<ISharedService<Ecategory>, CategoryService>();
            services.AddScoped<ISharedService<Eelectionduration>, ElectionDurationService>();
            services.AddScoped<ISharedService<Egender>, GenderService>();
            services.AddScoped<ISharedService<Egovernorate>, GovernorateService>();
            services.AddScoped<ISharedService<Emunicipalname>, MunicipalNameService>();
            services.AddScoped<ISharedService<Eplaceandregnum>, PlaceAndRegNumService>();
            services.AddScoped<ISharedService<Eplaceofrelease>, PlaceOfReleaseService>();
            services.AddScoped<ISharedService<Eplaceswithinthemunicipal>, PlacesWithInTheMunicipalService>();
            services.AddScoped<ISharedService<Eplaceofresidencevillage>, PlaceofResidenceVillageService>();
            services.AddScoped<ISharedService<Eplaceofresidence>, PlaceOfResidenceService>();
            services.AddScoped<ISharedService<Erole>, RoleService>();
            services.AddScoped<ISharedService<Euserinformation>, UserInformationService>();
            services.AddScoped<ISharedService<Euser>, UserService>();
            services.AddScoped<ISharedService<Emunicipalstatus>, MunicipalStatusService>();
            services.AddScoped<ISharedService<Euservoted>, UserVotedService>();
            services.AddScoped<ISharedService<Euservote>, UserVoteService>();
            services.AddScoped<ISharedService<Euser>, UserService>();
            services.AddScoped<IMunicipalStatusService, MunicipalStatusService>();
            services.AddScoped<IMunicipalNameService, MunicipalNameService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IRegisterService, UserService>();
            services.AddScoped<ISharedService<Etestimonial>, TestimonialService>();
            services.AddScoped<ISharedService<Eaboutu>, AboutuService>();
            services.AddScoped<ISharedService<Ehome>, HomeService>();
            services.AddScoped<ISharedService<Econtactu>, ContactuService>();
            services.AddScoped<ISharedService<Ereview>, ReviewService>();
            services.AddScoped<IEmailVerifyingService, EmailVerifyingService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IPlacesWithInTheMunicipalService, PlacesWithInTheMunicipalService>();
            services.AddScoped<IUserVotedService, UserVotedService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddControllers();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("policy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
