# StanOK
Для создания БД:
1. Отредактировать файл App.config, строка 19, имя пользователя и пароль
2. Средства -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов
3. Ввести по очереди Add-migration postgres, update-database -verbose

Заполнение начальных данных в файле Migrations/Configuration/Seed. После редактирования нужно снова прописать Add-migration postgres, update-database -verbose, предварительно удалив файл миграции из Migrations (иначе его хуёвит чето)
