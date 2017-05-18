$projects = @(
    "./src/AspNetSeo/AspNetSeo.csproj",
    "./src/AspNetSeo.CoreMvc/AspNetSeo.CoreMvc.csproj",
    "./src/AspNetSeo.Mvc/AspNetSeo.Mvc.csproj")

foreach ($project in $projects) {
    dotnet restore $project --no-cache
    dotnet build $project -c Release
    dotnet pack $project --no-build -c Release --output '../..'
}