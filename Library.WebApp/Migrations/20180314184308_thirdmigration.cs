using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.WebApp.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BooksAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BookId",
                table: "BooksAuthors",
                newName: "IX_BooksAuthors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BooksAuthors",
                newName: "IX_BooksAuthors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAuthors_Authors_AuthorId",
                table: "BooksAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAuthors_Books_BookId",
                table: "BooksAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksAuthors_Authors_AuthorId",
                table: "BooksAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAuthors_Books_BookId",
                table: "BooksAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors");

            migrationBuilder.RenameTable(
                name: "BooksAuthors",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_BooksAuthors_BookId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksAuthors_AuthorId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
