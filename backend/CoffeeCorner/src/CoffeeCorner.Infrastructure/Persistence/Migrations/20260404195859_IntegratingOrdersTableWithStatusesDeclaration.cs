using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeCorner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntegratingOrdersTableWithStatusesDeclaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE orders.""Orders""
                ALTER COLUMN ""Status"" TYPE integer
                USING CASE
                    WHEN ""Status"" = 'Created' THEN 0
                    WHEN ""Status"" = 'PendingPayment' THEN 1
                    WHEN ""Status"" = 'Paid' THEN 2
                    WHEN ""Status"" = 'Processing' THEN 3
                    WHEN ""Status"" = 'Shipped' THEN 4
                    WHEN ""Status"" = 'InTransit' THEN 5
                    WHEN ""Status"" = 'OutForDelivery' THEN 6
                    WHEN ""Status"" = 'Delivered' THEN 7
                    WHEN ""Status"" = 'Completed' THEN 8
                    WHEN ""Status"" = 'Cancelled' THEN 9
                    WHEN ""Status"" = 'Failed' THEN 10
                    WHEN ""Status"" = 'ReturnRequested' THEN 11
                    WHEN ""Status"" = 'Returned' THEN 12
                    WHEN ""Status"" = 'Refunded' THEN 13
                    WHEN ""Status"" = 'OnHold' THEN 14
                    ELSE 0
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE orders.""Orders""
                ALTER COLUMN ""Status"" TYPE text
                USING CASE
                    WHEN ""Status"" = 0 THEN 'Created'
                    WHEN ""Status"" = 1 THEN 'PendingPayment'
                    WHEN ""Status"" = 2 THEN 'Paid'
                    WHEN ""Status"" = 3 THEN 'Processing'
                    WHEN ""Status"" = 4 THEN 'Shipped'
                    WHEN ""Status"" = 5 THEN 'InTransit'
                    WHEN ""Status"" = 6 THEN 'OutForDelivery'
                    WHEN ""Status"" = 7 THEN 'Delivered'
                    WHEN ""Status"" = 8 THEN 'Completed'
                    WHEN ""Status"" = 9 THEN 'Cancelled'
                    WHEN ""Status"" = 10 THEN 'Failed'
                    WHEN ""Status"" = 11 THEN 'ReturnRequested'
                    WHEN ""Status"" = 12 THEN 'Returned'
                    WHEN ""Status"" = 13 THEN 'Refunded'
                    WHEN ""Status"" = 14 THEN 'OnHold'
                    ELSE 'Created'
                END;
            ");
        }
    }
}
