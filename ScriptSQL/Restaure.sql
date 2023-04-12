ALTER DATABASE GammeEntretien
SEt SINGLE_USER WITH ROLLBACK IMMEDIATE

use master
go

RESTORE DATABASE GammeEntretien
FROM DISK = 'C:\ScriptSQL\BackupBd\GammeEntretien.Bak'

ALTER DATABASE GammeEntretien
SEt Multi_USER