## Antes de Tudo:

Antes de iniciar a aplicação, executar o seguinte comando com  docker instalado:

    docker run -d --name=my_sql_app -e MYSQL_ROOT_PASSWORD=AppTeste -p 3306:3306 mysql:8
    
 ##### Se for testar pelo swagger, ao inserir o bearer JWT, favor remover o nome "Bearer" do token