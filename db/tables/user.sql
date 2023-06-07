-- not in use
create table if not exists tracker_app.user
(
    user_id           bigserial
        constraint pk_user_id primary key,
    email             text      not null,
    password          text      not null,
    salt              text      not null,
    first_name        text      not null,
    last_name         text,
    created_date_time timestamp not null,
    updated_date_time timestamp not null
);
