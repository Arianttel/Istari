CREATE TABLE "sauron"."adventurer"(
	"id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	"name" VARCHAR(25) NOT NULL,
	"password" VARCHAR(50) NOT NULL
);
