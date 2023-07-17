using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Migrations
{
    [Migration(202307131504)]
    public class _202307131504_AddedBlockTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Blocks");

        }

        public override void Up()
        {
            CreatBlocks();    
        }

        private void CreatBlocks()
        {
                        Create.Table("Blocks")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30).NotNullable()
            .WithColumn("UnitCount").AsInt32().NotNullable()
            .WithColumn("ComplexId").AsInt32().NotNullable()
            .ForeignKey("FK_Blocks_Compelexes", "Complexes", "Id");
        }
    }
}
