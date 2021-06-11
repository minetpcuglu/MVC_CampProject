namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_imagechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "Image", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "Image", c => c.String(maxLength: 100));
        }
    }
}
