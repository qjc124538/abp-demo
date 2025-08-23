# abp-demo

基于abp-9.2的示例项目 官网: https://abp.io/

使用 efCore code first 模式, 支持切换数据库SqlServer, Oracle, Dm

# 数据库创建

efCore code first 支持根据连接字符串自动创建sqlserver数据库

Oracle/Dm数据库需要提前创建用户并且赋予角色权限

# 数据库连接字符串

同步在Qjc.AbpDemo.Web/appsettings.json 与 Qjc.AbpDemo.DbMigrator/appsettings.json

设置“ConnectionStrings.SqlServer/Oracle/Dm”的值(注意不要修改key)

设置“DataBaseType”的值为“ConnectionStrings”中的key

# 数据库迁移

设置启动项目为“Qjc.AbpDemo.DbMigrator”并执行, 如果失败需要重新初始化迁移命令

1.删除"Qjc.AbpDemo.Application/Migrations"文件夹

2.打开"程序包管理控制台" 确保启动项目与运行项目都是“Qjc.AbpDemo.Application”

3.执行 Add-Migration Init

4.执行 Update-Database

# 测试访问

运行"Qjc.AbpDemo.Web"后，访问swagger

