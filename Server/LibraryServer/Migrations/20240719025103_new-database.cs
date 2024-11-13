using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryServer.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorName);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    publisherName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.publisherName);
                });

            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    LibId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.LibId);
                    table.ForeignKey(
                        name: "FK_Librarians_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReaderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.ReaderId);
                    table.ForeignKey(
                        name: "FK_Readers_Accounts_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    publisherName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    authorName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_authorName",
                        column: x => x.authorName,
                        principalTable: "Authors",
                        principalColumn: "AuthorName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_publisherName",
                        column: x => x.publisherName,
                        principalTable: "Publishers",
                        principalColumn: "publisherName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportCards",
                columns: table => new
                {
                    reportCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moneyIn = table.Column<int>(type: "int", nullable: false),
                    moneyOut = table.Column<int>(type: "int", nullable: false),
                    moneyInSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moneyOutSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    libId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCards", x => x.reportCardId);
                    table.ForeignKey(
                        name: "FK_ReportCards_Librarians_libId",
                        column: x => x.libId,
                        principalTable: "Librarians",
                        principalColumn: "LibId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReaderCarts",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderCarts", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_ReaderCarts_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "ReaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowCards",
                columns: table => new
                {
                    brcardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expidate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowCards", x => x.brcardId);
                    table.ForeignKey(
                        name: "FK_BorrowCards_Accounts_userId",
                        column: x => x.userId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowCards_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnCards",
                columns: table => new
                {
                    reCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhieuMuonSach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnCards", x => x.reCardId);
                    table.ForeignKey(
                        name: "FK_ReturnCards_BorrowCards_PhieuMuonSach",
                        column: x => x.PhieuMuonSach,
                        principalTable: "BorrowCards",
                        principalColumn: "brcardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_authorName",
                table: "Books",
                column: "authorName");

            migrationBuilder.CreateIndex(
                name: "IX_Books_publisherName",
                table: "Books",
                column: "publisherName");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowCards_bookId",
                table: "BorrowCards",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowCards_userId",
                table: "BorrowCards",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_UserId",
                table: "Librarians",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderCarts_ReaderId",
                table: "ReaderCarts",
                column: "ReaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Readers_UserId1",
                table: "Readers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCards_libId",
                table: "ReportCards",
                column: "libId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCards_PhieuMuonSach",
                table: "ReturnCards",
                column: "PhieuMuonSach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ReaderCarts");

            migrationBuilder.DropTable(
                name: "ReportCards");

            migrationBuilder.DropTable(
                name: "ReturnCards");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.DropTable(
                name: "BorrowCards");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
