# TestRabbitMq

For find list rabbitmq : docker exec -it 8e2d7b4544ab5365ba3f617ccdc39377e8d32bef5c0e1faa56a12b1b478d7ad3  rabbitmq-plugins list
if didn't find this rabbitmq_management from rabbitmq  list 
From the plugin list you provided, it looks like the rabbitmq_management plugin, which is responsible for the RabbitMQ management UI, is not listed or enabled. 
This would explain why you are experiencing issues accessing the management UI and could potentially be related to your connection problems.

Steps to Enable the RabbitMQ Management Plugin
Enable the Management Plugin

To enable the RabbitMQ management plugin, you can use the rabbitmq-plugins command. Run the following command inside the RabbitMQ container:

sh
Копировать код
docker exec -it <rabbitmq_container_id> rabbitmq-plugins enable rabbitmq_management
Replace <rabbitmq_container_id> with your RabbitMQ container ID or name.

Verify Plugin is Enabled

After enabling the plugin, verify that it is now listed as enabled:

sh
Копировать код
docker exec -it <rabbitmq_container_id> rabbitmq-plugins list
You should see rabbitmq_management listed as enabled (indicated by [e*] or similar).

Restart RabbitMQ

To ensure the changes take effect, restart the RabbitMQ container:

sh
Копировать код
docker-compose restart rabbitmq
Access the Management UI

Once the management plugin is enabled and RabbitMQ is restarted, try accessing the management UI again at http://localhost:15672.

Summary
The absence of the rabbitmq_management plugin in the list of plugins indicates that it is not enabled. 
Enabling this plugin should resolve the issue with accessing the management UI and could help with resolving some of the connection issues you are facing. 
After enabling the plugin, restart the RabbitMQ container and verify that the management UI is accessible.