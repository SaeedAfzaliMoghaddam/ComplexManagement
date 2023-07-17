using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Migrations
{
    [Migration(202307131558)]
    public class _202307131558_AddedunitsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Units");
        }

        public override void Up()
        {
            CreateUnits();
        }
        void CreateUnits()
        {
            Create.Table("Units")
.WithColumn("Id").AsInt32().PrimaryKey().Identity()
.WithColumn("Name").AsString(30).NotNullable()
.WithColumn("ResidenseType").AsInt32().NotNullable()
.WithColumn("BlockId").AsInt32().NotNullable()
.ForeignKey("FK_Units_Blocks", "Blocks", "Id");
        }
    }
}
