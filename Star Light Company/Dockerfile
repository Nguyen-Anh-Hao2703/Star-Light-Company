# Bước 1: Build dự án
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy toàn bộ code vào Docker (Thay vì chỉ copy từng file lẻ dễ lỗi đường dẫn)
COPY . .

# Tìm và khôi phục các gói NuGet (Tự động quét file .csproj)
RUN dotnet restore

# Build và Publish ra thư mục /app
RUN dotnet publish -c Release -o /app

# Bước 2: Chạy dự án
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app .

# Render yêu cầu App chạy trên Port 80 hoặc theo biến môi trường PORT
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Star Light Company.dll"]