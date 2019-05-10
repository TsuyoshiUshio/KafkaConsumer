# Kafka Command Sample 

# Create a topic

```
$ kubectl get svc --all-namespaces
```

Find the zookeeper. This time name doesn't work. So I go with the IP address. 

```
$ kubectl exec -it kafkaclient /bin/bash
# cd bin
# ./kafka-topics.sh --zookeeper 10.0.109.15:2181 --topic nigel --create --partitions 3 --replication-factor 1
```

NOTE: ususally `ohkafkach2-zookeeper` should work instead of `10.0.109.15`

Then go back to your console on your PC.

# Getting metadata

You can see the newly created nigel topic.

```
$ kafkacat -b 40.76.55.228:31090 -L
```
# Consumer

This command consume messages.

```
$ kafkacat -b 40.76.55.228:31090 -C -t nigel
hello
congra
nigel said that
```

# Producer

This command produce messages.

```
$ kafkacat -b 40.76.55.228:31090 -P -t nigel
% Reached end of topic nigel [1] at offset 0
% Reached end of topic nigel [2] at offset 0
% Reached end of topic nigel [0] at offset 0
hello
% Reached end of topic nigel [2] at offset 1
congra
% Reached end of topic nigel [0] at offset 1
nigel said that
% Reached end of topic nigel [2] at offset 2
```

# Reference

[Configuring Kafka on Kubernetes makes available from an external client with helm](https://medium.com/@tsuyoshiushio/configuring-kafka-on-kubernetes-makes-available-from-an-external-client-with-helm-96e9308ee9f4)