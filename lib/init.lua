-- dotnet-resource-postgresql-library main module.
-- Renders Resources/Persistence.cs with EF Core + Npgsql into the service project directory.
--
-- The calling archetype is responsible for adding the corresponding
-- NuGet package to the .csproj:
--   Npgsql.EntityFrameworkCore.PostgreSQL
--
-- API:
--   local pg = require("dotnet-resource-postgresql")
--   pg.render(context, { destination = context:get("project-name") })
--
-- Context contract:
--   prefix-name  — kebab-case first segment (e.g. "billing")
--   suffix-name  — kebab-case second segment (e.g. "service")
--   PrefixName   — PascalCase first segment (e.g. "Billing")  [set by Cases.programming()]
--   SuffixName   — PascalCase second segment (e.g. "Service") [set by Cases.programming()]

local M = {}

function M.render(context, opts)
    opts = opts or {}
    local d = opts.destination
    if d and d ~= "" then
        directory.render("contents", context, { destination = d })
    else
        directory.render("contents", context)
    end
    return context
end

return M
