USE GammeEntretien;
GO  
BACKUP DATABASE GammeEntretien
TO DISK = 'D:\GammeEntretien\ScriptSql\BackupBd\GammeEntretien.Bak'  
   WITH FORMAT,  
      MEDIANAME = 'GammeEntretienBackup',  
      NAME = 'Full Backup base GammeEntretien';  
GO  





