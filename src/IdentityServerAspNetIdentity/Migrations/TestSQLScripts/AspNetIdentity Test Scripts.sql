use IdentityServerAspNetIdentity;

select top 100 * from dbo.AspNetRoleClaims with(nolock)
select top 100 * from dbo.AspNetRoles with(nolock)
select top 100 * from dbo.AspNetUserClaims with(nolock)
select top 100 * from dbo.AspNetUserLogins with(nolock)
select top 100 * from dbo.AspNetUserRoles with(nolock)
select top 100 * from dbo.AspNetUsers with(nolock)
select top 100 * from dbo.AspNetUserTokens with(nolock)