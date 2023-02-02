using HotChocolate.Types;
using NekoSpace.Data.Models.User;

namespace NekoSpace.API.GraphQL.Users
{
    public class UserType : ObjectType<NekoUser>
    {
        protected override void Configure(IObjectTypeDescriptor<NekoUser> descriptor)
        {
            descriptor.Description("Information about User.");

            descriptor.
                Field(p => p.Id)
                .Description("User Id");

            descriptor.
                Field(p => p.About)
                .Description("Information about yourself provided by the user");

            descriptor
                .Field(p => p.UserName)
                .Description("A unique nickname invented by the user");

            descriptor
                .Field(p => p.Email)
                .Description("User Email address");

            descriptor
                .Field(p => p.EmailConfirmed)
                .Description("Is the email сonfirmed");

            descriptor
                .Field(p => p.LockoutEnabled)
                .Description("Gets a flag indicating if the user could be lock out");

            descriptor
                .Field(p => p.LockoutEnd)
                .Description("Get date and time, int UTC, when user lockout ends");

            descriptor
                .Field(p => p.FavoriteAnimes)
                .Description("User's favorite anime");

            descriptor
                .Field(p => p.TwoFactorEnabled)
                .Ignore();

            descriptor
                .Field(p => p.AccessFailedCount)
                .Ignore();

            descriptor
                .Field(p => p.ConcurrencyStamp)
                .Ignore();

            descriptor
                .Field(p => p.NormalizedEmail)
                .Ignore();

            descriptor
                .Field(p => p.NormalizedUserName)
                .Ignore();

            descriptor
                .Field(p => p.PasswordHash)
                .Ignore();

            descriptor
                .Field(p => p.PhoneNumber)
                .Ignore();

            descriptor
                .Field(p => p.PhoneNumberConfirmed)
                .Ignore();


            descriptor
                .Field(p => p.TwoFactorEnabled)
                .Ignore();

        }
    }
}
