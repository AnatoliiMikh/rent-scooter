
1. Конфигурация баз данных для докера (Readme)
2. Запустить Докер. После запуска докера удалить появившуюся "postgres"
3. Запустить проект через RentScooter.sln
4. В терминале проекта прописать "docker-compose build", подождать, пока докер соберется. Поднять все образы командой "docker-compose up".
5. Для удобного изучения всех функций запустить api, который лежит на 10000:80. Перейти в swagger через Api description. Здесь можно создать пользователя через Post запрос (name = email). Далее - авторизоваться под созданным пользователем с правами чтения и записи. Здесь можно приступить к изучению проекта.


Для запуска PostgreSQL и MSSQL через Docker:
**Start the PostgreSQL in the Docker**

docker pull postgres

docker run --name postgres --restart=always -p 25432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Passw0rd -e POSTGRES_DB=postgres -v postgresvolume:/var/lib/postgresql/data -d postgres

**Start the MSSQL in the Docker**

docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" --name=SQL --restart=always -e "MSSQL_SA_PASSWORD=Passw0rd" -p 1433:1433 -v sqlvolume:/var/opt/mssql -v sqlvolume:/var/opt/dtemp -d mcr.microsoft.com/mssql/server:2022-latest
