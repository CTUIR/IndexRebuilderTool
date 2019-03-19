use CDMS_PROD
go

select
OBJECT_NAME(ind.OBJECT_ID) AS TableName,
ind.name AS IndexName,
avg_fragmentation_in_percent
from sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) indexstats
INNER JOIN sys.indexes ind 
ON ind.object_id = indexstats.object_id
AND ind.index_id = indexstats.index_id
--where OBJECT_NAME(ind.OBJECT_ID) = 'Activities' and ind.name = 'PK_dbo.Activities'
where OBJECT_NAME(ind.OBJECT_ID) not like '%MigrationHistory'
and ind.name is not null
--and OBJECT_NAME(ind.OBJECT_ID) not like 'NonClusteredIndex%'
and OBJECT_NAME(ind.OBJECT_ID) != 'AuditJournals'
and OBJECT_NAME(ind.OBJECT_ID) != 'ELMAH_Error'
and OBJECT_NAME(ind.OBJECT_ID) != 'sysdiagrams'
and indexstats.alloc_unit_type_desc != 'LOB_DATA'
--and ind.name like 'PK_dbo.%'
Order by TableName
