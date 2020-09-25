# TataisenergoTest

## TataisenergoTest.Infrastructure database setup

- Create MS SQL database named `TaeTest`
- Create MS SQL login with creds `TaeTest;TaeTest`
- Apply migrations with `dotnet ef database update -p TataisenergoTest.Infrastructure -s TataisenergoTest.Web`
- Fill in the table `Encrypt_Settings` with encryption pairs. ___Caution: pairs are CASE-SENSITIVE___
