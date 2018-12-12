-- Create table
create table WELF_STAFF
(
  EPF    NUMBER(5),
  COMPANY 	VARCHAR2(20),
  ZONE  	VARCHAR2(100),
  BRANCH   VARCHAR2(100),
  DEPARTMENT   VARCHAR2(100),
  NAME   VARCHAR2(200),
  Primary key (EPF,COMPANY)
)
tablespace TBS_HNBA_DAT
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
 