using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectTek.CoreLayer.Repositoires.AnswerRep;
using ProjectTek.CoreLayer.Repositoires.ExamQuesitonRep;
using ProjectTek.CoreLayer.Repositoires.ExamRep;
using ProjectTek.CoreLayer.Repositoires.UserRep;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.DataAccesLayer.Contexts;
using ProjectTek.DataAccesLayer.Repositoires.AnswerRep;
using ProjectTek.DataAccesLayer.Repositoires.ExamQuesitonRep;
using ProjectTek.DataAccesLayer.Repositoires.ExamRep;
using ProjectTek.DataAccesLayer.Repositoires.UserRep;
using ProjectTek.DataAccesLayer.Repositoires.WiredArticleRep;


namespace ProjectTek.DataAccesLayer.Services
{
    public static class ServiceRegistiration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<ProjectTekDbContext>(op => op.UseSqlServer(ConfigService.ConnectionString),ServiceLifetime.Singleton);
            services.AddSingleton<IAnswerReadRepository, AnswerReadRepository>();
            services.AddSingleton<IAnswerWriteRepository, AnswerWriteRepository>();
            services.AddSingleton<IExamQuestionWriteRepository, ExamQuestionWriteRepository>();
            services.AddSingleton<IExamWriteRepository, ExamWriteRepository>();
            services.AddSingleton<IExamQuestionReadRepository, ExamQuesitonReadRepository>();
            services.AddSingleton<IExamReadRepository, ExamReadRepository>();
            services.AddSingleton<IUserReadRepository, UserReadRepository>();
            services.AddSingleton<IUserWriteRepository, UserWriteRepository>();
            services.AddSingleton<IWiredArticleWriteRepository, WiredArticlesWriteRepository>();
            services.AddSingleton<IWiredArticleReadRepository, WiredArticlesReadRepository>();



        }
    }
}

