🗂️ Cấu trúc thư mục
src/
├── Tourism.API/               # ASP.NET Web API (entrypoint)
├── Tourism.Application/       # Application layer (DTOs, UseCases, Interfaces)
│   ├── Interfaces/            # Interface cho DAS/Services
│   ├── Models/Dto/            # DTO cho input/output
│   └── Services/              # Application Services
├── Tourism.Domain/            # Domain layer (Entities, Aggregates, Services)
│   ├── Entities/              # Business Entities (e.g., Department, JobTitle)
│   ├── Services/              # Domain Interfaces
│   └── ValueObjects/          # Giá trị bất biến (nếu có)
├── Tourism.Infrastructure/    # Data Access & Implementation của interfaces
│   ├── Data/                  # DbContext, Migrations
│   └── Das/                   # Implement các DAS
├── Tourism.Shared/            # Chứa lớp dùng chung (PagedResult, BaseEntity, Enum, Error, v.v.)
│   ├── Pagination/            # PagedRequest, PagedResult
│   ├── Models/Predefine/      # PredefineDataRequest, PredefineDataModel
│   └── Enums/                 # Enum định nghĩa chung
└── Tourism.sln                # Solution file

🧠 Kiến trúc tổng quan
graph TD
  UI[Tourism.API]
  UI --> App[Tourism.Application]
  App --> Domain[Tourism.Domain]
  App --> Infra[Tourism.Infrastructure]
  Infra --> Domain
  Domain --> Shared[Tourism.Shared]
  App --> Shared
  Infra --> Shared

🔧 Cài đặt & chạy
Prerequisites
  .NET 8+
  EF Core CLI (dotnet ef)
  SQL Server hoặc PostgreSQL (có thể cấu hình trong appsettings.json)

Chạy local
  cd src/Tourism.API
  dotnet run