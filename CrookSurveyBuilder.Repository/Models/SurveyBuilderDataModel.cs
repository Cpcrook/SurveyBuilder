using CrookSurveyBuilder.Repository.Models;

namespace CrookSurveyBuilder.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SurveyBuilderDataModel : DbContext
    {
        // Your context has been configured to use a 'SurveyDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CrookSurveyBuilder.Repository.SurveyDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SurveyDataModel' 
        // connection string in the application configuration file.
        public SurveyBuilderDataModel()
            : base("name=SurveyDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceOptions { get; set; }
        public DbSet<TextInputQuestion> TextInputQuestions { get; set; }
       

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}