use FLETNIX;

CREATE TABLE CustomerFeedback (
	movie_id int NOT NULL,
	customer_mail_address VARCHAR(255) NOT NULL,
	feedback_date date NOT NULL,
	comments VARCHAR(255) NOT NULL,
	rating int NOT NULL,
	CONSTRAINT PK_CUSTOMERFEEDBACK PRIMARY KEY (movie_id, customer_mail_address),
	CONSTRAINT FK_MOVIE_CUSTOMERFEEDBACK_MOVIE_ID FOREIGN KEY (movie_id) REFERENCES Movie(movie_id) ON UPDATE CASCADE,
	CONSTRAINT FK_CUSTOMER_CUSTOMERFEEDBACK_CUSTOMER_MAIL_ADDRESS FOREIGN KEY (customer_mail_address) REFERENCES Customer(customer_mail_address) ON UPDATE CASCADE
);

INSERT INTO CustomerFeedback VALUES (11, 'consequat.auctor@scelerisqueloremipsum.com', '11-oct-2014', 'Nice movie with a very good plot', 7);
INSERT INTO CustomerFeedback VALUES (12, 'lectus@placerataugue.edu', '10-apr-2014', 'Not as good as the original movie', 6);

CREATE TABLE MovieAwards (
	movie_id int NOT NULL,
	award VARCHAR(255) NOT NULL,
	result VARCHAR(10) NOT NULL,
	number_of_awards VARCHAR(255) NOT NULL,
	CONSTRAINT PK_MOVIEAWARDS PRIMARY KEY (movie_id, award, result),
	CONSTRAINT FK_MOVIEAWARDS_MOVIE_MOVIE_ID FOREIGN KEY (movie_id) REFERENCES Movie(movie_id) ON UPDATE CASCADE
);

INSERT INTO MovieAwards VALUES (11, 'Oscar', 'Won', '7');
INSERT INTO MovieAwards VALUES (11, 'BAFTA Film Awards', 'Won', '2');
INSERT INTO MovieAwards VALUES (11, 'BAFTA Film Awards', 'Nominated', '3');

UPDATE Movie SET URL = 'https://www.youtube.com/watch?v=87cUqFA3mnw'