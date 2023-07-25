using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Migrations
{
    [Migration(202307251130)]
    public class _202307251130_AddedComplexesTable:Migration
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
          WithColumn("UnitCapacity").AsInt32().NotNullable();
        }
    }
}
