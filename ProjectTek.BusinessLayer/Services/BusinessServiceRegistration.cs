using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ProjectTek.BusinessLayer.Validators;
using ProjectTek.CoreLayer.Repositoires.AnswerRep;
using ProjectTek.CoreLayer.Repositoires.ExamQuesitonRep;
using ProjectTek.CoreLayer.Repositoires.ExamRep;
using ProjectTek.CoreLayer.Repositoires.UserRep;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.BusinessLayer.Services
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {

            services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UserValidator>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddSession();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/User/Index";
            });
           


        }
    }
}
