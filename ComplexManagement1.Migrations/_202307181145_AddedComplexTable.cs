using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Migrations
{
    [Migration(202307181145)]
    public class _202307181145_AddedComplexTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Complexes");
        }

        public override void Up()
        {
            Create.Table("Complexes").
          WithColumn("Id").AsInt32().PrimaryKey().Identity().
          WithColumn("Name").AsString(30).NotNullable().
          WithColumn("UnitCount").AsInt32().NotNullable();
        }
    }
}
