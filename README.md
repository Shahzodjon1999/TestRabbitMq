# TestRabbitMq
This project good working in the Docker
And also good seccessfully connect to PostgreSql and also RabbitMQ 
also save and get data from PostgreSql and RabbitMQ 




For find list rabbitmq : docker exec -it 8e2d7b4544ab5365ba3f617ccdc39377e8d32bef5c0e1faa56a12b1b478d7ad3  rabbitmq-plugins list
if didn't find this rabbitmq_management from rabbitmq  list 

1) docker exec -it <rabbitmq_container_id> rabbitmq-plugins enable rabbitmq_management

2) docker exec -it <rabbitmq_container_id> rabbitmq-plugins list

Restart RabbitMQ

3) docker-compose restart rabbitmq

Once the management plugin is enabled and RabbitMQ is restarted, try accessing the management UI again at http://localhost:15672.
