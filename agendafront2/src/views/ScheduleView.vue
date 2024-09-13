<template>
  <div class="agenda">
    <ScheduleComp msg="Bem-vindo a Agenda!" />
  </div>
</template>

<script>

import ScheduleComp from '@/components/ScheduleComp.vue'

export default {
  name: 'AgendaView',
  components: {
    ScheduleComp
  }
}
</script>