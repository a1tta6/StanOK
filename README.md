# StanOK
Для создания БД:
1. Отредактировать файл App.config, строка 19, имя пользователя и пароль
2. Средства -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов
3. Ввести по очереди Enable-migrations, Add-migration postgres, update-database -verbose
