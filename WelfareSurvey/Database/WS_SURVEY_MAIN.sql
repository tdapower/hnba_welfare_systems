-- Create table
create table WS_SURVEY_MAIN
(
  COMPANY		 VARCHAR2(20),
  EPF_NO             NUMBER(6),
  NAME         		 VARCHAR2(250),
  BRANCH_CODE        VARCHAR2(20),
  RES_ADDRESS_1      VARCHAR2(250),
  RES_ADDRESS_2      VARCHAR2(250),
  RES_ADDRESS_3      VARCHAR2(250),
  SEX	      		 VARCHAR2(1),
  MARITIAL_STATUS 	 VARCHAR2(1),
  NAME_OF_SPOUSE     VARCHAR2(250),
  NO_OF_CHILDREN  	 NUMBER(2),s
  SYSTEM_DATE        DATE,
  Primary key (COMPANY,EPF_NO)
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