import os
import openai
import requests
import base64

description_file = open('personData_description.txt', 'r')
description = description_file.read().replace(' ', '').split(';')
while ("" in description):
    description.remove("")

input = f"A {description[1]}, {description[2]}, {description[3]}, {description[4]}, {description[5]}, {description[0]} with {description[6]} hair"

try:
    openai.api_key = open("api_key.txt", "r", encoding="utf-8").read()
    response = openai.Image.create(
        prompt=input,
        n=5,
        size="1024x1024",
        response_format="b64_json"
    )
    for i in range(5):
        image_json = response['data'][i]['b64_json']

        img_data = base64.urlsafe_b64decode(image_json)
        with open(f'img{i}.jpg', 'wb') as handler:
            handler.write(img_data)

except openai.error.AuthenticationError:
    print("Incorrect API key provided.")

except:
    print("Unknown error has occured.")

# gender; height; body type; race; (disabled); age; hair color;
# male; short; well-built; white; disabled; young; black;
# personData_description.txt
