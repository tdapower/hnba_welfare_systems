-- Create table
create table WELF_TRIP_2017_TEMP
(
  SEQ_ID 	 NUMBER(5),
  COMPANY		 VARCHAR2(20),
  BRANCH_DEPT		 VARCHAR2(100), 
  EPF_NO             NUMBER(6),
  INSURED_NAME        VARCHAR2(250),
  DOB 	 VARCHAR2(20),
  RELATION     VARCHAR2(50),
  Primary key (SEQ_ID)
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