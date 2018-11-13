using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Migrations
{
    [Migration(201811071429)]
    public class Migrator201811071429_Create_Table2 : Migration
    {
        public override void Down()
        {
            Delete.Table("table2");
        }

        public override void Up()
        {
            Create.Table("table2")
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("Text").AsString();
        }
    }
}
