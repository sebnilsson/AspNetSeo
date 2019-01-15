$projects = @(
    "./src/AspNetSeo/AspNetSeo.csproj",
    "./src/AspNetSeo.CoreMvc/AspNetSeo.CoreMvc.csproj")

dotnet restore "./AspNetSeo.sln"
dotnet build "./AspNetSeo.sln" -c Release --no-restore

foreach ($project in $projects) {
    dotnet pack $project --no-build --no-restore -c Release --output '../..'
}