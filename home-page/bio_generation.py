import os
import openai

api_key = open("/api_key.txt", "r", encoding="utf-8").read()

openai.api_key = api_key

response = openai.Completion.create(
    model="text-davinci-003",
    prompt="write a short bio of a single man in first person in Hungarian",
    temperature=1,
    max_tokens=256,
    top_p=1,
    frequency_penalty=0,
    presence_penalty=0
)

print(response['choices'][0]['text'])
