using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Migrations
{
    [Migration(202307231300)]
    public class _202307231300_AddedBlocksTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Blocks");
        }

        public override void Up()
        {
            Create.Table("Blocks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Name").AsString(30).NotNullable()
           .WithColumn("UnitCount").AsInt32().NotNullable()
           .WithColumn("ComplexId").AsInt32().NotNullable().ForeignKey("FK_Blocks_Complexes", "Complexes", "Id");

        }
    }
}
