namespace Online_Assessment_Project.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesDone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "AnswerLable", c => c.String());
            AlterColumn("dbo.Answers", "IsCorrect", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "IsCorrect", c => c.Byte(nullable: false));
            DropColumn("dbo.Answers", "AnswerLable");
        }
    }
}
