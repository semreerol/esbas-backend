using System;
using System.Xml;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration.UserSecrets;

#nullable disable

namespace esbas_internship_backendproject.Migrations
{
    public partial class AddStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    CostCenterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.CostCenterID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CostCenterID = table.Column<int>(type: "int", nullable: false),
                    TaskID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_CostCenters_CostCenterID",
                        column: x => x.CostCenterID,
                        principalTable: "CostCenters",
                        principalColumn: "CostCenterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departments_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateTable(
                name: "Event_Location",
                columns: table => new
                {
                    L_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Location", x => x.L_ID);
                });

            migrationBuilder.CreateTable(
                name: "Event_Type",
                columns: table => new
                {
                    T_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Type", x => x.T_ID);
                });

            
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event_Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    L_ID = table.Column<int>(type: "int", nullable: false),
                    T_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Event_Location_L_ID",
                        column: x => x.L_ID,
                        principalTable: "Event_Location",
                        principalColumn: "L_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Event_Type_T_ID",
                        column: x => x.T_ID,
                        principalTable: "Event_Type",
                        principalColumn: "T_ID",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateTable(
                name: "Events_Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Users_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_Users_CardID",
                        column: x => x.CardID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRegistrationID = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    G_ID = table.Column<int>(type: "int", nullable: false),
                    MC_ID = table.Column<int>(type: "int", nullable: false),
                    OC_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_User_Gender_G_ID",
                        column: x => x.G_ID,
                        principalTable: "User_Gender",
                        principalColumn: "G_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Main_Characteristicts_MC_ID",
                        column: x => x.MC_ID,
                        principalTable: "Main_Characteristicts",
                        principalColumn: "MC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Other_Characteristicts_OC_ID",
                        column: x => x.OC_ID,
                        principalTable: "Other_Characteristicts",
                        principalColumn: "OC_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Gender",
                columns: table => new
                {
                    G_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Gender", x => x.G_ID);
                });
        
            migrationBuilder.CreateTable(
                name: "Main_Characteristicts",
                columns: table => new
                {
                    MC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main_Characteristicts", x => x.MC_ID);
                });

             migrationBuilder.CreateTable(
                 name: "Other_Characteristicts",
                 columns: table => new
                 {
                     OC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                     Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                     Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                 },
                 constraints: table =>
                 {
                  table.PrimaryKey("PK_Other_Characteristicts", x => x.OC_ID);
                 });


            migrationBuilder.CreateIndex(
             name: "IX_Departments_CostCenterID",
             table: "Departments",
             column: "CostCenterID");

            migrationBuilder.CreateIndex(
             name: "IX_Departments_TaskID",
             table: "Departments",
             column: "TaskID");

            migrationBuilder.CreateIndex(
             name: "IX_Events_L_ID",
             table: "Events",
             column: "L_ID");

            migrationBuilder.CreateIndex(
            name: "IX_Events_T_ID",
            table: "Events",
            column: "T_ID");
            
             
            migrationBuilder.CreateIndex(
            name: "IX_Users_DepartmentID",
            table: "Users",
            column: "DepartmentID");

            migrationBuilder.CreateIndex(
            name: "IX_Users_G_ID",
            table: "Users",
            column: "G_ID");

            migrationBuilder.CreateIndex(
            name: "IX_Users_MC_ID",
            table: "Users",
            column: "MC_ID");

        migrationBuilder.CreateIndex(
            name: "IX_Users_OC_ID",
            table: "Users",
            column: "OC_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.DropTable(name: "Events_Users");
        migrationBuilder.DropTable(name: "Users");
        migrationBuilder.DropTable(name: "Events");
        migrationBuilder.DropTable(name: "Departments");
        migrationBuilder.DropTable(name: "Other_Characteristicts");
        migrationBuilder.DropTable(name: "Main_Characteristicts");
        migrationBuilder.DropTable(name: "User_Gender");
        migrationBuilder.DropTable(name: "Tasks");
        migrationBuilder.DropTable(name: "Event_Type");
        migrationBuilder.DropTable(name: "Event_Location");
        migrationBuilder.DropTable(name: "CostCenters");
        }
    }
}
    
    


