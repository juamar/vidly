namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'59c79570-7481-4821-96e2-0b9f12f88a57', N'juanihu94@gmail.com', 0, N'AHEabT53VxMox4bo1zxNj0bZ7au1aB2ZEiyLlNXSLZmmQ4GpbrfQVRBNcptrtHTLXg==', N'b795f707-da71-42c5-9ed3-e20a38a6668b', NULL, 0, 0, NULL, 1, 0, N'juanihu94@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aea41fb2-2b5e-444e-8465-a7acc2e72d71', N'contacto@tecandweb.com', 0, N'AH+gfZaSo172JVRcr6h1Wp/kGtlvLkg17LGVUFQrspB1+XhYNC8hzzqRe7QdkpzG6g==', N'e5a5649a-3f3f-4577-85b8-12fcb1590ffb', NULL, 0, 0, NULL, 1, 0, N'contacto@tecandweb.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5005034e-6f2f-4a02-a9ef-eadf7db1a49c', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aea41fb2-2b5e-444e-8465-a7acc2e72d71', N'5005034e-6f2f-4a02-a9ef-eadf7db1a49c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
