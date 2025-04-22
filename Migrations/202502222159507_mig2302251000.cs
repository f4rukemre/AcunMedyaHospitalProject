using System.Data.Entity.Migrations;
using System;

    
    public partial class mig2302251000 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PatientPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "PatientPhone");
        }
    }

