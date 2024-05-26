using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPay.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AlteraRelacionamentoTransacaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Usuarios_UsuarioId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_UsuarioId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Transacoes");

            migrationBuilder.AlterColumn<bool>(
                name: "StatusTransacao",
                table: "Transacoes",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "booleano");

            migrationBuilder.CreateTable(
                name: "TransacaoUsuario",
                columns: table => new
                {
                    TransacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosTransacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoUsuario", x => new { x.TransacoesId, x.UsuariosTransacaoId });
                    table.ForeignKey(
                        name: "FK_TransacaoUsuario_Transacoes_TransacoesId",
                        column: x => x.TransacoesId,
                        principalTable: "Transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransacaoUsuario_Usuarios_UsuariosTransacaoId",
                        column: x => x.UsuariosTransacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoUsuario_UsuariosTransacaoId",
                table: "TransacaoUsuario",
                column: "UsuariosTransacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransacaoUsuario");

            migrationBuilder.AlterColumn<bool>(
                name: "StatusTransacao",
                table: "Transacoes",
                type: "booleano",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Transacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_UsuarioId",
                table: "Transacoes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Usuarios_UsuarioId",
                table: "Transacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
