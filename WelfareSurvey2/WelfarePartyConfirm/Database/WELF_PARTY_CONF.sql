-- Create table
create table WELF_PARTY_CONF
(
  EPF_NO             NUMBER(6),
  SYSTEM_DATE        DATE,
  Primary key (EPF_NO)
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