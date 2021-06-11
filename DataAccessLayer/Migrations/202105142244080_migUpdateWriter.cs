namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migUpdateWriter : DbMigration
    {
        public override void Up()  //güncellencek kısım 
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 100));
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
