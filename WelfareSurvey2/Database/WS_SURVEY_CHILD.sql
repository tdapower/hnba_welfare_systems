-- Create table
create table WS_SURVEY_CHILD
(
  ID         NUMBER(5),
  EMP_EPF     NUMBER(5),
  NAME       VARCHAR2(250),
  DOB        DATE,
  SEX      VARCHAR2(1),
  Primary key (ID)
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