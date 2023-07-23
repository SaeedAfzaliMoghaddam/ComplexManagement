using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Migrations
{
    [Migration(202307231310)]
    public class _202307231310_AddedUnitsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Units");
        }

        public override void Up()
        {
            Create.Table("Units")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("ResidenseType").AsInt32().NotNullable()
                .WithColumn("BlockId").AsInt32().NotNullable().ForeignKey("FK_Units_Blocks", "Blocks", "Id");

        }
    }
}
