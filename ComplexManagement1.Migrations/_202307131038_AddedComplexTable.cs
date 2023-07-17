using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Migrations
{
    [Migration(202307131038)]
    public class _202307131038_AddedComplexTable : Migration
    {
        public override void Down()
        {
            DeleteComplexesTable();
        }

        public override void Up()
        {
            CreatComplexesTable();
        }

        private void CreatComplexesTable()
        {
            Create.Table("Complexes").
          WithColumn("Id").AsInt32().PrimaryKey().Identity().
          WithColumn("Name").AsString(30).NotNullable().
          WithColumn("UnitCount").AsInt32().NotNullable();
        }
        private void DeleteComplexesTable()
        {
            Delete.Table("Complexes");

        }

    }


}
