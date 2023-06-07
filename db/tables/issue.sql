create table if not exists tracker_app.issue
(
    issue_id          bigserial
        constraint pk_issue primary key,
    title             text      not null,
    description       text      not null,
    created_date_time timestamp not null,
    updated_date_time timestamp not null
);
