using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    public partial class IntialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hrs",
                columns: table => new
                {
                    hrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    higherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    occpation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reponsibilty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hrs", x => x.hrId);
                });

            migrationBuilder.CreateTable(
                name: "NotifyHeaders",
                columns: table => new
                {
                    notifyHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemDescription = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    attachments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyHeaders", x => x.notifyHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreHeaders",
                columns: table => new
                {
                    storeHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemNoInExpenditureRegister = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noOfEntryInTheRegisterOfIncomingGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notifyHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreHeaders", x => x.storeHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    woreda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeLimit = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    hrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customers_Hrs_hrId",
                        column: x => x.hrId,
                        principalTable: "Hrs",
                        principalColumn: "hrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestHeaders",
                columns: table => new
                {
                    requestHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    attachments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHeaders", x => x.requestHeaderId);
                    table.ForeignKey(
                        name: "FK_RequestHeaders_Hrs_hrId",
                        column: x => x.hrId,
                        principalTable: "Hrs",
                        principalColumn: "hrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnHeaders",
                columns: table => new
                {
                    returnHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnHeaders", x => x.returnHeaderId);
                    table.ForeignKey(
                        name: "FK_ReturnHeaders_Hrs_hrId",
                        column: x => x.hrId,
                        principalTable: "Hrs",
                        principalColumn: "hrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotifyItems",
                columns: table => new
                {
                    notifyItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    notifyHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyItems", x => x.notifyItemId);
                    table.ForeignKey(
                        name: "FK_NotifyItems_NotifyHeaders_notifyHeaderId",
                        column: x => x.notifyHeaderId,
                        principalTable: "NotifyHeaders",
                        principalColumn: "notifyHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    storeItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shelfNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    availableQuantity = table.Column<int>(type: "int", nullable: false),
                    availability = table.Column<bool>(type: "bit", nullable: false),
                    storeHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.storeItemId);
                    table.ForeignKey(
                        name: "FK_StoreItems_StoreHeaders_storeHeaderId",
                        column: x => x.storeHeaderId,
                        principalTable: "StoreHeaders",
                        principalColumn: "storeHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsersTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustemerWarranties",
                columns: table => new
                {
                    warrantyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warantiyname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warantiyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warantiySubCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warantiyWoreda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warantiyRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustemerWarranties", x => x.warrantyId);
                    table.ForeignKey(
                        name: "FK_CustemerWarranties_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestItems",
                columns: table => new
                {
                    requestItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestedQuantity = table.Column<int>(type: "int", nullable: false),
                    approvedQuantity = table.Column<int>(type: "int", nullable: false),
                    attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItems", x => x.requestItemId);
                    table.ForeignKey(
                        name: "FK_RequestItems_RequestHeaders_requestHeaderId",
                        column: x => x.requestHeaderId,
                        principalTable: "RequestHeaders",
                        principalColumn: "requestHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnItems",
                columns: table => new
                {
                    returnItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    returnHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnItems", x => x.returnItemId);
                    table.ForeignKey(
                        name: "FK_ReturnItems_ReturnHeaders_returnHeaderId",
                        column: x => x.returnHeaderId,
                        principalTable: "ReturnHeaders",
                        principalColumn: "returnHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approves",
                columns: table => new
                {
                    approveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    approvedQuantity = table.Column<int>(type: "int", nullable: false),
                    storeItemId = table.Column<int>(type: "int", nullable: false),
                    requestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approves", x => x.approveId);
                    table.ForeignKey(
                        name: "FK_Approves_RequestItems_requestId",
                        column: x => x.requestId,
                        principalTable: "RequestItems",
                        principalColumn: "requestItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Approves_StoreItems_storeItemId",
                        column: x => x.storeItemId,
                        principalTable: "StoreItems",
                        principalColumn: "storeItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributes",
                columns: table => new
                {
                    distributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    approveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributes", x => x.distributeId);
                    table.ForeignKey(
                        name: "FK_Distributes_Approves_approveId",
                        column: x => x.approveId,
                        principalTable: "Approves",
                        principalColumn: "approveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hrs",
                columns: new[] { "hrId", "LastName", "birthDate", "firstName", "fpId", "gender", "higherDate", "middleName", "occpation", "rank", "reponsibilty" },
                values: new object[,]
                {
                    { 1, "አለሙ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7582), "የሱፍ", "26505157", "ወንድ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7591), "ፈንታ", "ጀማሪ የሶፍትዌር ባለሙያ", "J_V / ጀማሪ", "የሲቪል ሰራተኛ" },
                    { 2, "አሊ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7593), "ሙሀመድ", "26505152", "ወንድ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7593), "ሁሴን", "ጀማሪ የሶፍትዌር ባለሙያ", "J_V / ጀማሪ", "የሲቪል ሰራተኛ" },
                    { 3, "ኦርጌሳ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7594), "ሁንዴ", "26505156", "ወንድ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7594), "ረጋሳ", "ጀማሪ የሶፍትዌር ባለሙያ", "J_V / ጀማሪ", "የሲቪል ሰራተኛ" },
                    { 4, "ታደሰ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7595), "ሰማይነህ", "26505155", "ወንድ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7596), "ከበደ", "ጀማሪ የዌብሳይት አስተዳደር ባለሙያ", "J_V / ጀማሪ", "የሲቪል ሰራተኛ" },
                    { 5, "ተንኮሉ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7596), "ተረፈ", "fp2650", "ወንድ", new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Local).AddTicks(7597), "በከለ", "ዋና ክፍል ሀላፊ", "ዋና ክፍል", "ዋና ክፍል" }
                });

            migrationBuilder.InsertData(
                table: "NotifyHeaders",
                columns: new[] { "notifyHeaderId", "attachments", "itemDescription" },
                values: new object[,]
                {
                    { 1, "Upload your Attachment", "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች" },
                    { 2, "Upload your Attachment", "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33fcc74d-265a-4faa-a0c9-e76cb6abd580", "d69a8986-163e-486d-a17d-480acc7d035c", "Admin", "Admin" },
                    { "3fc8cda0-d45c-4949-b7b4-081b9cc21d8b", "895ad922-498e-4f70-b10a-9f4be6c73b14", "mmd", "MMD" },
                    { "9983c6cd-45e3-4141-8c2a-90a8e1637a7a", "0a4be211-9047-458a-b5cc-3028e8c37334", "storeman", "storeman" }
                });

            migrationBuilder.InsertData(
                table: "StoreHeaders",
                columns: new[] { "storeHeaderId", "donor", "itemNoInExpenditureRegister", "noOfEntryInTheRegisterOfIncomingGoods", "notifyHeaderId" },
                values: new object[,]
                {
                    { 1, "የኢትዮጵያ መከላከያ", "no. 1", "10 items", 0 },
                    { 2, "የኢትዮጵያ መከላከያ", "no. 2", "10 items", 0 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerId", "birthDate", "birthPlace", "homeNumber", "hrId", "name", "occupation", "phoneNumber", "region", "sex", "subCity", "timeLimit", "woreda" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7652), new TimeSpan(0, 3, 0, 0, 0)), "ብቸና ከተማ", "+251923531946", 1, "የሱፍ", "ጀማሪ የሶፍትዌር ባለሙያ", "+251923531946", "አማራ", "ወንድ", "ንፋስ ስልክ ላፍቶ", new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7667), new TimeSpan(0, 3, 0, 0, 0)), "02" },
                    { 2, new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 3, 0, 0, 0)), "ባቲ ከተማ", "+251923531946", 1, "ሙሀመድ", "ጀማሪ የሶፍትዌር ባለሙያ", "+251923531946", "አማራ", "ወንድ", "ቦሌ", new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 3, 0, 0, 0)), "02" },
                    { 3, new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, 3, 0, 0, 0)), "ጊንጪ ከተማ", "+251923531946", 2, "ሁንዴ", "ጀማሪ የሶፍትዌር ባለሙያ", "+251923531946", "ኦሮሚያ", "ወንድ", "ንፋስ ስልክ ላፍቶ", new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, 3, 0, 0, 0)), "02" },
                    { 4, new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7674), new TimeSpan(0, 3, 0, 0, 0)), "ብቸና ከተማ", "+251923531946", 1, "ሰማይነህ", "ጀማሪ የሶፍትዌር ባለሙያ", "+251923531946", "አማራ", "ወንድ", "ንፋስ ስልክ ላፍቶ", new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7674), new TimeSpan(0, 3, 0, 0, 0)), "02" },
                    { 5, new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 3, 0, 0, 0)), "ብቸና ከተማ", "+251923531946", 1, "የሱፍ", "ጀማሪ የሶፍትዌር ባለሙያ", "+251923531946", "አማራ", "ወንድ", "ንፋስ ስልክ ላፍቶ", new DateTimeOffset(new DateTime(2022, 8, 1, 10, 39, 47, 957, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 3, 0, 0, 0)), "02" }
                });

            migrationBuilder.InsertData(
                table: "NotifyItems",
                columns: new[] { "notifyItemId", "model", "name", "notifyHeaderId", "quantity", "type" },
                values: new object[,]
                {
                    { 1, "ክላሽ ጠብመንጃ", "ክላሽ ጠብመንጃ", 1, 10, "ክላሽ ጠብመንጃ" },
                    { 2, "ክላሽ ጠብመንጃ ካርታ", "ክላሽ ጠብመንጃ ካርታ", 2, 10, "ክላሽ ጠብመንጃ ካርታ" },
                    { 3, "የፒኬአም መተረየስ", "የፒኬአም መተረየስ", 1, 10, "የፒኬአም መተረየስ" },
                    { 4, "ካኑኒ ኤስ ሽጉጥ", "ካኑኒ ኤስ ሽጉጥ", 2, 10, "ካኑኒ ኤስ ሽጉጥ" },
                    { 5, "ጠብመንጃ AK-47", "ክላሽ ጠብመንጃ AK-47", 2, 10, "ክላሽ ጠብመንጃ" }
                });

            migrationBuilder.InsertData(
                table: "RequestHeaders",
                columns: new[] { "requestHeaderId", "attachments", "description", "hrId" },
                values: new object[,]
                {
                    { 1, "Upload your Attachment", "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", 1 },
                    { 2, "Upload your Attachment", "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", 2 }
                });

            migrationBuilder.InsertData(
                table: "StoreItems",
                columns: new[] { "storeItemId", "availability", "availableQuantity", "itemDescription", "model", "quantity", "serialNo", "shelfNo", "storeHeaderId", "storeNo", "type" },
                values: new object[,]
                {
                    { 1, true, 10, "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", "ክላሽ ጠብመንጃ", 10, "serial 1", "No. 1", 1, "No. 1", "ክላሽ ጠብመንጃ" },
                    { 2, true, 10, "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", "ክላሽ ጠብመንጃ ካርታ", 10, "serial 2", "No 2", 1, "No. 1", "ክላሽ ጠብመንጃ ካርታ" },
                    { 3, true, 10, "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", "የፒኬአም መተረየስ", 10, "serial 3", "No. 1", 2, "N0 2", "የፒኬአም መተረየስ" },
                    { 4, true, 10, "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", "ክላሽ ጠብመንጃ AK-47", 10, "serial 4", "No 2", 1, "No. 1", "ክላሽ ጠብመንጃ" },
                    { 5, true, 10, "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", "ካኑኒ ኤስ ሽጉጥ", 10, "serial 5", "No. 1", 2, "N0 2", "ካኑኒ ኤስ ሽጉጥ" },
                    { 6, true, 10, "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", "ካኑኒ ኤስ ሽጉጥ", 10, "serial 6", "No. 1", 1, "N0 2", "ካኑኒ ኤስ ሽጉጥ" }
                });

            migrationBuilder.InsertData(
                table: "CustemerWarranties",
                columns: new[] { "warrantyId", "customerId", "warantiyAddress", "warantiyRegion", "warantiySubCity", "warantiyWoreda", "warantiyname" },
                values: new object[,]
                {
                    { 1, 1, "ብቸና ከተማ", "አማራ", "ንፋስ ስልክ ላፍቶ", "02", "የሱፍ" },
                    { 2, 1, "ባቲ ከተማ", "አማራ", "ቦሌ", "02", "ሙሀመድ" },
                    { 3, 1, "ጊንጪ ከተማ", "ኦሮሚያ", "ንፋስ ስልክ ላፍቶ", "02", "ሁንዴ" },
                    { 4, 1, "ብቸና ከተማ", "አማራ", "ንፋስ ስልክ ላፍቶ", "02", "ሰማይነህ" }
                });

            migrationBuilder.InsertData(
                table: "RequestItems",
                columns: new[] { "requestItemId", "approvedQuantity", "attachments", "model", "name", "requestHeaderId", "requestedQuantity", "status", "type" },
                values: new object[,]
                {
                    { 1, 0, "Upload your Attachment", "ክላሽ ጠብመንጃ", "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", 1, 10, "Pending", "ክላሽ ጠብመንጃ" },
                    { 2, 0, "Upload your Attachment", "ክላሽ ጠብመንጃ ካርታ", "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", 1, 5, "Pending", "ክላሽ ጠብመንጃ ካርታ" },
                    { 3, 0, "Upload your Attachment", "የፒኬአም መተረየስ", "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", 1, 10, "Pending", "የፒኬአም መተረየስ" },
                    { 4, 0, "Upload your Attachment", "ክላሽ ጠብመንጃ AK-47", "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች", 2, 10, "Pending", "ክላሽ ጠብመንጃ" },
                    { 5, 0, "Upload your Attachment", "ካኑኒ ኤስ ሽጉጥ", "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", 2, 10, "Pending", "ካኑኒ ኤስ ሽጉጥ" },
                    { 6, 0, "Upload your Attachment", "ካኑኒ ኤስ ሽጉጥ", "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች", 2, 5, "Pending", "ካኑኒ ኤስ ሽጉጥ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approves_requestId",
                table: "Approves",
                column: "requestId");

            migrationBuilder.CreateIndex(
                name: "IX_Approves_storeItemId",
                table: "Approves",
                column: "storeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustemerWarranties_customerId",
                table: "CustemerWarranties",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_hrId",
                table: "Customers",
                column: "hrId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributes_approveId",
                table: "Distributes",
                column: "approveId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyItems_notifyHeaderId",
                table: "NotifyItems",
                column: "notifyHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeaders_hrId",
                table: "RequestHeaders",
                column: "hrId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_requestHeaderId",
                table: "RequestItems",
                column: "requestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnHeaders_hrId",
                table: "ReturnHeaders",
                column: "hrId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItems_returnHeaderId",
                table: "ReturnItems",
                column: "returnHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_storeHeaderId",
                table: "StoreItems",
                column: "storeHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustemerWarranties");

            migrationBuilder.DropTable(
                name: "Distributes");

            migrationBuilder.DropTable(
                name: "NotifyItems");

            migrationBuilder.DropTable(
                name: "ReturnItems");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UsersTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Approves");

            migrationBuilder.DropTable(
                name: "NotifyHeaders");

            migrationBuilder.DropTable(
                name: "ReturnHeaders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RequestItems");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "RequestHeaders");

            migrationBuilder.DropTable(
                name: "StoreHeaders");

            migrationBuilder.DropTable(
                name: "Hrs");
        }
    }
}
